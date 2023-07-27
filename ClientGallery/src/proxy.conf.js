const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:7103", //5001
    secure: false
  }
]

module.exports = PROXY_CONFIG;
