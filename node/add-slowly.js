module.exports = (callback, a, b, timeout) =>
    setTimeout(() => callback(null, `${a} + ${b} = ${a + b}`), timeout);