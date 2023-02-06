const express = require('express')
const router = express.Router()
const apiController = require('../controllers/api.controller')

router.get('/events',
    apiController.getEvents)


router.get('/topEvents',
    apiController.getTopEvents)

// videos
router.get('/videos',
    apiController.getVideos)

module.exports = router