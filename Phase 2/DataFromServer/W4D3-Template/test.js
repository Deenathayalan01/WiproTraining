// test.js
const assert = require('assert');
const fetchData = require('./callbacksExample');

describe('fetchData function', () => {
  it('should fetch data from server with callback', (done) => {
    fetchData((err, data) => {
      assert.strictEqual(err, null); // Assert that there's no error
      assert.strictEqual(data, 'Data from server'); // Assert the retrieved data
      done(); // Call done() to signal that the test is complete
    });
  });
});


// promisesExample.test.js
const fetchDataPromise = require('./promisesExample');

describe('fetchData function', () => {
  it('should fetch data from server using Promise', () => {
    return fetchDataPromise().then((data) => {
      assert.strictEqual(data, 'Data from server'); // Assert the retrieved data
    });
  });
});


// asyncAwaitExample.test.js
const getData = require('./asyncAwaitExample');
describe('getData function', () => {
  it('should fetch data from server using async/await', async () => {
    const data = await getData();
    assert.strictEqual(data, 'Data from server'); // Assert the retrieved data
  });
});


// errorHandlingExample.test.js
const divide = require('./errorHandlingExample');

describe('divide function', () => {
  it('should divide two numbers', () => {
    assert.strictEqual(divide(6, 2), 3); // Assert division result
  });

  it('should throw an error when dividing by zero', () => {
    assert.throws(() => {
      divide(6, 0); // Attempt to divide by zero
    }, Error); // Assert that the error thrown is an instance of Error
  });
});

