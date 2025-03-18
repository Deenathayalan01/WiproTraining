// callbacksExample.js

function fetchData(callback) {
  setTimeout(() => {
    const data = 'Data from server';
    callback(null, data);
  }, 1000); // Simulate fetching data from server with a delay of 1 second
}

module.exports = fetchData;  