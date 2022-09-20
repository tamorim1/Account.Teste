const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/votes",
      "/candidates"
    ],
    target: "http://localhost:5005",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
