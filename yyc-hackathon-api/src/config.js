const dotenv = require('dotenv')
dotenv.config()

const config = {
    serverHost: process.env.SERVER_HOST || 'localhost',
    serverPort: process.env.SERVER_PORT ? Number(process.env.SERVER_PORT) : 4000,
    apiPrefix: process.env.API_PREFIX || '/api',
    apiKey: process.env.API_KEY || '24ea1031-5821-488b-9b95-a1d9896d929d',
}

module.exports = config