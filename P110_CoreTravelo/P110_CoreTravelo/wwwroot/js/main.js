//HOME PAGE start
$(document).ready(function()
{
    "use strict";

    //hansi yaxsi oglana gore bunu yaziriq???
    var vw = $(window).outerWidth();
    var totalWidth = $("body #slider .s-window .s-slider li").length * vw;
    $("body #slider .s-window .s-slider").css("width", totalWidth + "px");


    //HEADER SECTION start
    $(".s-top-left .s-sub-lang").hide();
    $(document).on("mouseover",".s-top-left .s-lang",function()
    {        
        $(".s-top-left .s-sub-lang").show();
    });
    $(document).on("mouseout",".s-top-left .s-lang",function()
    {        
        $(".s-top-left .s-sub-lang").hide();
    });

    $(".s-top-right .s-sub-currency").hide();
    $(document).on("mouseover",".s-top-right .s-currency",function()
    {        
        $(".s-top-right .s-sub-currency").show();
    });
    $(document).on("mouseout",".s-top-right .s-currency",function()
    {        
        $(".s-top-right .s-sub-currency").hide();
    });

    $(".s-bars-navbar").hide();
    $(document).on("click",".s-bars",function()
    {
        $(".s-bars-navbar").slideToggle();
    });
    //HEADER SECTION end
    
    //S-BARS-NAVBAR SECTION start
    $(".s-minus").hide();
    $(".s-bars-navbar-submenu").hide();
    $(document).on("click",".s-plus",function(e)
    {
        $(e.target).parent().next().slideToggle();
        $(e.target).next().show();    
    });
    $(document).on("click",".s-minus",function(e)
    {
        $(e.target).parent().next().slideToggle();
        $(this).hide(500);
        $(e.target).prev().show(500);
    });
    //S-BARS-NAVBAR SECTION end    

    //SLIDER SECTION start
    let index = 0;
    setInterval(function()
    {
        index++;
        //let vWidth = $("#slider .s-slider").innerWidth()/$("#slider .s-slider li").length;
        
        $("#slider .s-slider").css(
            {
                left: -index * vw + "px"
            });  
         
        if(index === $("#slider .s-slider li").length)
        {
            index = 0;
            $("#slider .s-slider").css(
                {
                    left: -index * vw + "px"
                });  
        }
    },5000);
    $(document).on("click","#slider .s-arrow-right",function()
    {
        index++;
        //let vWidth = $("#slider .s-slider").innerWidth()/$("#slider .s-slider li").length;
        
        $("#slider .s-slider").css(
            {
                left: -index * vw + "px"
            })  
         
        if(index === $("#slider .s-slider li").length)
        {
            index = 0;
            $("#slider .s-slider").css(
                {
                    left: -index * vw + "px"
                })  
        }
    });
    $(document).on("click","#slider .s-arrow-left",function()
    {
        index--;
        //let vWidth = $("#slider .s-slider").innerWidth()/$("#slider .s-slider li").length;
        
        $("#slider .s-slider").css(
            {
                left: -index * vw + "px"
            });  
         
        if(index < 0)
        {
            index = $("#slider .s-slider li").length - 1;
            $("#slider .s-slider").css(
                {
                    left: -index * vw + "px"
                });  
        }
    });
    //SLIDER SECTION end

    //TAB SECTION start
    $(document).on("click","#tab .s-tab li",function(e)
    {
        e.preventDefault();
        $("#tab .s-tab li.active").removeClass("active");
        $(this).addClass("active");
        $("#tab .s-tab-info.active").removeClass("active");
        let activeLiId = $(this).attr("data-id");
        let activeInfoId = $(`#tab .s-tab-info[data-id="${activeLiId}"]`);
        activeInfoId.addClass("active");
    });

    let number = 1;
    $(document).on("click","#tab .s-tab-slider .s-arrow-right",function()
    {
        $(this).prev().prev().removeClass("color");
        $(this).addClass("color");
        number++;
        let activeLi = $("#tab .s-tab-slider ul li.active");
        activeLi.removeClass("active");
        if(number !== $("#tab .s-tab-slider ul li").length + 1)
        {
            let liNumber = $(`#tab .s-tab-slider ul li[data-number="${number}"]`).addClass("active");
            $("#tab .s-tab-info.active").removeClass("active");
            let activeLiId = $(liNumber).attr("data-number");
            let activeInfoId = $(`#tab .s-tab-info[data-type="${activeLiId}"]`);
            activeInfoId.addClass("active");
        }
        else
        {
            number = 1;
            let liNumber = $(`#tab .s-tab-slider ul li[data-number="${number}"]`).addClass("active");
            $("#tab .s-tab-info.active").removeClass("active");
            let activeLiId = $(liNumber).attr("data-number");
            let activeInfoId = $(`#tab .s-tab-info[data-type="${activeLiId}"]`);
            activeInfoId.addClass("active");
        }
    });

    $(document).on("click","#tab .s-tab-slider .s-arrow-left",function()
    {
        $(this).next().next().removeClass("color");
        $(this).addClass("color");
        number--;
        let activeLi = $("#tab .s-tab-slider ul li.active");
        activeLi.removeClass("active");
        if(number > 0)
        {
            let liNumber = $(`#tab .s-tab-slider ul li[data-number="${number}"]`).addClass("active");
            $("#tab .s-tab-info.active").removeClass("active");
            let activeLiId = $(liNumber).attr("data-number");
            let activeInfoId = $(`#tab .s-tab-info[data-type="${activeLiId}"]`);
            activeInfoId.toggleClass("active");
        }
        else
        {
            number = $("#tab .s-tab-slider ul li").length;
            let liNumber = $(`#tab .s-tab-slider ul li[data-number="${number}"]`).addClass("active");
            $("#tab .s-tab-info.active").removeClass("active");
            let activeLiId = $(liNumber).attr("data-number");
            let activeInfoId = $(`#tab .s-tab-info[data-type="${activeLiId}"]`);
            activeInfoId.toggleClass("active");
        }
    });
    //TAB SECTION end

    //BOTTOM SECTION start
    $(document).on("click", "#bottom .s-bottom-right i", function () {
        // let interval = setInterval(function()
        // {
        //     let documentScrollHeight = $(document).scrollHeight;
        //     window.scrollTo(0,documentScrollHeight);
        // },500);


        $("html").animate({ scrollTop: 0 }, 1500);
    });

    
    //BOTTOM SECTION end
});
//HOME PAGE end

//PAGES PAGE start
$(document).ready(function()
{
    $(document).on("click","#holiday-tab .s-holiday-tab li",function(e)
    {
        e.preventDefault();
        $("#holiday-tab .s-holiday-tab li.active").removeClass("active");
        $(this).addClass("active");
        $("#holiday-tab .s-holiday-tab-desc.active").removeClass("active");
        let activeLiId = $(this).attr("data-id");
        let activeDesc = $(`#holiday-tab .s-holiday-tab-desc[data-id="${activeLiId}"]`);
        activeDesc.addClass("active");
    })
});
//PAGES PAGE end
