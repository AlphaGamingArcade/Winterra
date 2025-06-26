const activeUploads = [];

function CustomUploadAdapterPluginFactory(formId) {
  return function CustomUploadAdapterPlugin(editor) {
    editor.plugins.get("FileRepository").createUploadAdapter = (loader) => {
      return new MyUploadAdapter(loader, formId);
    };
  };
}

class MyUploadAdapter {
  constructor(loader, formId) {
    this.loader = loader;
    this.formId = formId;
  }

  upload() {
    return this.loader.file.then((file) => {
      const uploadPromise = new Promise((resolve, reject) => {
        const formData = new FormData();
        formData.append("upload", file);

        // Optional: disable submit
        const form = document.getElementById(this.formId);
        const submitBtn = form?.querySelector('[type="submit"]');
        submitBtn.classList.add("disable-submit");
        if (submitBtn) submitBtn.disabled = true;

        fetch("/Upload/Attach/Image", {
          method: "POST",
          body: formData,
          credentials: "same-origin",
        })
          .then((res) => res.json())
          .then((data) => {
            if (data.success && data.url) {
              resolve({ default: data.url });
            } else {
              reject(data.error || "Upload failed.");
            }
          })
          .catch(() => reject("Upload error"));
      });

      // Track the promise
      activeUploads.push(uploadPromise);

      // Remove from array when done
      uploadPromise.finally(() => {
        const index = activeUploads.indexOf(uploadPromise);
        if (index > -1) activeUploads.splice(index, 1);

        // Re-enable the form submit when done (if no more uploads pending)
        const form = document.getElementById(this.formId);
        const submitBtn = form?.querySelector('[type="submit"]');
        if (submitBtn && activeUploads.length === 0) {
          submitBtn.disabled = false;
          submitBtn.classList.remove("disable-submit");
        }
      });

      return uploadPromise;
    });
  }

  abort() {
    // Optional: handle cancelation
  }
}
