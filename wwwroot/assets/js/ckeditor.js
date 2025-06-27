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

function renderVideoEmbeds(container = document) {
  const oembeds = container.querySelectorAll("oembed[url]");

  oembeds.forEach((element) => {
    const url = element.getAttribute("url");

    const embedData = getEmbedData(url);
    if (embedData) {
      const wrapper = document.createElement("div");
      Object.assign(wrapper.style, {
        position: "relative",
        width: "100%",
        paddingBottom: "56.25%", // 16:9
        height: "0",
        overflow: "hidden",
      });

      const iframe = document.createElement("iframe");
      iframe.src = embedData.embedUrl;
      iframe.allow =
        "accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture";
      iframe.allowFullscreen = true;

      Object.assign(iframe.style, {
        position: "absolute",
        top: "0",
        left: "0",
        width: "100%",
        height: "100%",
        border: "0",
      });

      wrapper.appendChild(iframe);
      element.replaceWith(wrapper);
    }
  });

  function getEmbedData(url) {
    try {
      const parsed = new URL(url);
      const host = parsed.hostname;

      // YouTube
      if (host.includes("youtube.com") || host === "youtu.be") {
        let id = "";
        if (host === "youtu.be") {
          id = parsed.pathname.slice(1);
        } else if (parsed.searchParams.has("v")) {
          id = parsed.searchParams.get("v");
        }
        if (id) return { embedUrl: `https://www.youtube.com/embed/${id}` };
      }

      // Vimeo
      if (host.includes("vimeo.com")) {
        const id = parsed.pathname.split("/").filter(Boolean).pop();
        if (id) return { embedUrl: `https://player.vimeo.com/video/${id}` };
      }

      // Dailymotion
      if (host.includes("dailymotion.com") || host === "dai.ly") {
        let id = "";
        if (host === "dai.ly") {
          id = parsed.pathname.slice(1);
        } else {
          const parts = parsed.pathname.split("/");
          const videoIndex = parts.indexOf("video");
          if (videoIndex !== -1 && parts[videoIndex + 1]) {
            id = parts[videoIndex + 1];
          }
        }
        if (id)
          return { embedUrl: `https://www.dailymotion.com/embed/video/${id}` };
      }

      // Add more platforms here if needed
    } catch (e) {
      console.warn("Invalid video URL:", url);
      return null;
    }

    return null;
  }
}

function enhanceEditorContent(container = document) {
  renderVideoEmbeds(container);
  // future: resolve tables, style blockquotes, sanitize custom tags...
}

enhanceEditorContent();
