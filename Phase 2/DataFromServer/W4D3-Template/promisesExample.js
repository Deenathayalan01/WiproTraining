// promisesExample.js

function fetchData() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      const data = 'Data from server';
      resolve(data);
    }, 1000); // Simulate fetching data from server with a delay of 1 second
  });
}

module.exports = fetchData;
