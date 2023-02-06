/**
 * The main entry point of the application
 * @author Yang Ming
 * @version Jan 11, 2023
 */

require('module-alias/register')

const express = require('express')
const http = require('http')
const cors = require('cors')
const config = require('./config')
const logging = require('@utils/logging')
const bodyParser = require('body-parser')
const path = require('path')

const startServer = () => {
  const app = express()
  /** Log the request */
  app.use((req, res, next) => {
    /** Log the req */
    logging.info(`Incomming - METHOD: [${req.method}] - URL: [${req.url}] - IP: [${req.socket.remoteAddress}]`)

    res.on('finish', () => {
      /** Log the res */
      logging.info(`Result - METHOD: [${req.method}] - URL: [${req.url}] - IP: [${req.socket.remoteAddress}] - STATUS: [${res.statusCode}]`)
    })

    next()
  })

  // set up the form parser
  app.use(bodyParser.json())
  app.set(bodyParser.urlencoded({ extended: true }))
  // corss origin domain
  app.use(cors())

  /** Rules of our API */
  app.use((req, res, next) => {
    res.header('Access-Control-Allow-Origin', '*')
    res.header('Access-Control-Allow-Headers', 'Origin, X-Requested-With, Content-Type, Accept, Authorization')

    if (req.method === 'OPTIONS') {
      res.header('Access-Control-Allow-Methods', 'PUT, POST, PATCH, DELETE, GET')
      return res.status(200).json({})
    }

    next()
  })
  // set up a test route
  app.get(`${config.apiPrefix}/test`, async (req, res) => {
    res.json({ message: 'Hello World!!!!!' })
  })
  // get root path
  const rootPath = path.dirname(path.dirname(require.main.filename))
  // set up the static resource
  app.get('/public/video/*', function (req, res) {
    res.sendFile(rootPath + '/' + req.url)
  })

  const apiRouter = require('./routes/api.routes')
  app.use(config.apiPrefix, apiRouter)
  // start the server

  /** Error handling */
  app.use((_, res) => {
    const error = new Error('Not found')

    logging.error(error)

    res.status(404).json({
      message: error.message,
    })
  })

  http.createServer(app).listen(config.serverPort, config.serverHost,
    () => logging.info(`Server started http://${config.serverHost}:${config.serverPort}`))
}


startServer()