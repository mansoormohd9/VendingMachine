const PROXY_CONFIG = [
  {
    context: [
      "/api/account",
      "/api/buy",
      "/api/deposits",
      "/api/products",
      "/api/users",
    ],
    target: "https://localhost:7226",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
