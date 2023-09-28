/* @ts-nocheck*/
$(".log .up").click(function () {
    $(".log ul").slideToggle()
    if ($(this).children().eq(2).attr("class") == "fa-solid fa-chevron-down") {
        $(this).children().eq(2).attr("class","fa-solid fa-chevron-up")
    } else {
        $(this).children().eq(2).attr("class", "fa-solid fa-chevron-down")
    }
    $(this).toggleClass("active")
})

$(".menu .up").click(function () {
    $(".menu ul").slideToggle()
    $(".menu .fa-chevron-down").toggle()
    $(".menu .fa-chevron-up").toggle()
    $(this).toggleClass("active")
})

$(".filtermain .fa").click(function () {
    $(".filter").slideToggle()
})

$(".filter1").click(function () {
    $(".filter1 .fa-angle-down").toggle()
    $(".filter1 .fa-angle-up").toggle()
    $(".category1").toggle()
})

$(".filter2").click(function () {
    $(".filter2 .fa-angle-down").toggle()
    $(".filter2 .fa-angle-up").toggle()
    $(".category2").toggle()
})
var pText
$(".category1 p").click(function () {
    pText = $(this).text()
    $(".filter1 span").text(pText)
    $(".category1 p").removeClass("reng")
    $(this).toggleClass("reng")
    $(".category1 p i").removeClass("active1")
    $(this).children().eq(0).toggleClass("active1")
})


document.querySelector(".search input").addEventListener("keyup", function () {
    document.querySelectorAll(".card .name").forEach(y => {
        y.parentElement.parentElement.style.display = "none"
        if (y.innerText.toLowerCase().includes(document.querySelector("nav input").value.toLowerCase())) {
            y.parentElement.parentElement.style.display = "block"
        }
    })
})

//document.querySelector(".search1 input").addEventListener("keyup", function () {
//    document.querySelectorAll("tbody tr").forEach(x => {
//        x.style.display = "none"
//        if (x.innerText.toLowerCase().includes(document.querySelector(".search1 input").value.toLowerCase())) {
//            x.style.display = ""
//        }
//    })
//})

$(".category1 p").click(function () {
    a = $(this).attr("cat")
    $(".card").hide()
    if ($(this).attr("cat") == "show") {
        $(".card").show()
    } else {
        $("."+a).show()
    }
})


$(".check").click(function () {
    $(".check").removeClass("reng")
    $(this).toggleClass("check2")
})





document.querySelectorAll(".before select").forEach(x => {
    x.addEventListener("change", function () {
        document.querySelectorAll("tbody tr td p").forEach(y => {
            y.parentElement.parentElement.style.display = "none"
            if (y.innerText <= x.value) {
                y.parentElement.parentElement.style.display = ""
            }
        })
    })
})


var a = 0
document.querySelectorAll("table tbody td p").forEach(x=> {
    a++;
    x.innerText=a
})


$(".filtermain .fa-bars").click(function () {
    $("nav").toggle()
})
