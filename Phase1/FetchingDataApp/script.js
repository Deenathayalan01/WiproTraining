document.addEventListener("DOMContentLoaded", function () {
    const employeeBtn = document.getElementById("fetchEmployees");
    const userBtn = document.getElementById("fetchUser");
    const outputDiv = document.getElementById("output");

    // Fetch Employee Data
    employeeBtn.addEventListener("click", function () {
        fetch("https://dummy.restapiexample.com/api/v1/employees")
            .then(response => response.json())
            .then(data => {
                outputDiv.innerHTML = `<h3>Employee Data</h3><pre>${JSON.stringify(data, null, 2)}</pre>`;
            })
            .catch(error => {
                console.error("Error fetching employee data:", error);
                outputDiv.innerHTML = `<p class='text-danger'>Failed to fetch employee data.</p>`;
            });
    });

    // Fetch Random User Data
    userBtn.addEventListener("click", function () {
        fetch("https://randomuser.me/api/")
            .then(response => response.json())
            .then(data => {
                const user = data.results[0];
                outputDiv.innerHTML = `
                    <h3>Random User</h3>
                    <img src="${user.picture.large}" class="img-fluid rounded-circle" alt="User Image">
                    <p><strong>Name:</strong> ${user.name.first} ${user.name.last}</p>
                    <p><strong>Email:</strong> ${user.email}</p>
                `;
            })
            .catch(error => {
                console.error("Error fetching user data:", error);
                outputDiv.innerHTML = `<p class='text-danger'>Failed to fetch user data.</p>`;
            });
    });
});
