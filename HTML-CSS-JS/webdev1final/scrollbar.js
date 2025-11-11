$(window).scroll(function(){
    let pageHeight = $(document).height() - $(window).height();
    let amountScrolled = $(document).scrollTop();
    let scrollPercent = (amountScrolled / pageHeight) * 100;

    $('.progress-bar').css("width", scrollPercent + "%");
})