const apiController = {}
const events = require('../data/webscraped2.json')
const topEvents = require('../data/webscraped2-top.json')
const videos = require('../data/videos.json')

apiController.getVideos = async (req, res) => {
    try {
        res.json(videos)
    } catch (err) {
        res.status(500).json({ message: err.message })
    }
}

apiController.getEvents = async (req, res) => {
    try {
        const list = {
            eventName: [],
        }
        events.eventName.forEach((event, index) => {
            list.eventName.push({
                ...event,
                id: index,
            })
        })
        res.json(list)
    } catch (err) {
        res.status(500).json({ message: err.message })
    }
}


apiController.getTopEvents = async (req, res) => {
    try {
        const list = {
            eventName: [],
        }
        topEvents.eventName.forEach((event, index) => {
            list.eventName.push({
                ...event,
                id: index,
            })
        })
        res.json(list)
    } catch (err) {
        res.status(500).json({ message: err.message })
    }
}

module.exports = apiController