document.addEventListener("DOMContentLoaded", function () {
    console.log("Script loaded successfully!");

    // Smooth scroll for the timetable link
    document.querySelector(".nav-link[href='#timetable']").addEventListener("click", function (e) {
        e.preventDefault();
        document.querySelector(".timetable").scrollIntoView({ behavior: "smooth" });
    });
});
