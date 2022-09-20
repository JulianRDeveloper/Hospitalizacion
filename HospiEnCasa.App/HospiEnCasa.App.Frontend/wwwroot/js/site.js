// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
feather.replace();

// function alert1() {
//     Swal.fire({
//         // toast: false,
//         // keydownListenerCapture: false,
//         position: 'center',
//         icon: 'success',
//         title: 'Your work has been saved',
//         showConfirmButton: true,
//         //timer: 1500
//       })
//     //document.getElementById("f-fields").reset();    
// }

// $("#btn-s").click(function(){
//     Swal.fire({
//         position: 'center',
//         icon: 'success',
//         title: 'Your work has been saved',
//         showConfirmButton: true,
//         //timer: 1500
//       })
// })

$(function () {
    $('.btn_show').click(function (ev) {
    	ev.preventDefault();
        $('#contenido').slideToggle("slow");
    });
})



