$(document).ready(function () {
    $('.center').slick({
        centerMode: true,
        centerPadding: '60px',
        slidesToShow: 3,
        arrows: true,
        dots: true,
        responsive: [
          {
            breakpoint: 768,
            settings: {
              centerMode: true,
              arrows: true,
              centerMode: true,
              centerPadding: '60px',
              slidesToShow: 2
            }
          },
          {
            breakpoint: 480,
            settings: { 
              centerMode: true,
              arrows: true,
              centerMode: true,
              centerPadding: '60px',
              slidesToShow: 1
            }
          }
        ]
      });
      $('.one-time').slick({
        // dots: true,
        infinite: true,
        speed: 300,
        slidesToShow: 1,
        adaptiveHeight: true,
        arrows: true,
      });

      $('.fades').slick({
        dots: true,
        infinite: true,
        speed: 500,
        fade: true,
        cssEase: 'linear',
        arrows: false,
        autoplay: true,
        autoplaySpeed: 3000,
      });

      const $openSideNavButton = $("#openSideNav");
      const $menuNav = $(".menu-nav");
      const $closeNav = $(".close-nav");
    
      function toggleMenu() {
        if ($menuNav.hasClass("open")) {
          $menuNav.removeClass("open animate__slideInLeft");
          $menuNav.css("--animate-duration", "0.3s");
          $menuNav.addClass("animate__slideOutLeft");
    
          $menuNav.one("animationend", function () {
            $menuNav.removeClass("animate__slideOutLeft");
          });
        } else {
          $menuNav.addClass("open");
          $menuNav.css("display", "flex");
        }
      }
    
      $openSideNavButton.on("click", toggleMenu);
      $closeNav.on("click", toggleMenu);

      $('.sort-items button').on('click', function () {
        $('.sort-items button').removeClass('active'); // Remove active from all
        $(this).addClass('active'); // Add to the clicked one
      });

      $(".mobile-menu-item .fa-chevron-down").on("click", function (e) {
        e.preventDefault();
        $(this).closest('.mobile-menu-item')
               .find('.mobile-sub-menu')
               .slideToggle(300);
    });
    // Open the popup
    $("#openDownload").on("click", function (e) {
      e.preventDefault();

      $("body").append('<div class="backdrop-pop"></div>');
      $(".popup-download").css("display", "flex");
  });

  // Close the popup
  $("#closeDownload").on("click", function() {
      $(".popup-download").hide();
      $(".backdrop-pop").remove();
  });

  // Click the backdrop itself to close
  $(document).on("click", ".backdrop-pop", function() {
      $(".popup-download").hide();
      $(".backdrop-pop").remove();
  });
  
});
