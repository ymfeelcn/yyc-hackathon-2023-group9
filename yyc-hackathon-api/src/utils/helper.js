const fs = require('fs')
const config = require('../config')
const path = require('path')
const { promisify } = require('util')
const mv = promisify(fs.rename)
const rootPath = path.dirname(path.dirname(require.main.filename))
const helper = {}

helper.resError = (res, message, status) => {
  console.log('resError: ', message)
  return res.status(status || 500).json({ status: 'error', message: message })
}

helper.sum = (a, b) => {
  return a + b
}

helper.checkFileExists = (filePath) => {
  if (!filePath) return false
  try {
    return fs.existsSync(filePath)
  } catch (error) {
    console.log('checkFileExists is error', error)
    return false
  }
}

helper.deleteFile = (filePath) => {
  if (!filePath) return false
  try {
    fs.unlink(filePath, (err) => {
      if (err) {
        console.log(`${filePath} deleteFile is error`, err)
        return
      }
      console.log(`${filePath} is deleted`)
    })
  } catch (error) {
    console.log('deleteFile is error', error)
  }
}

helper.getUploadPath = (type, fileName) => {
  try {
    return `${rootPath}${config.upload.path}${type}/${fileName}`
  } catch (error) {
    console.log('getUploadPath is error', error)
    return ''
  }
}

helper.deleteUploadFile = async (type, image) => {
  try {
    const filename = image.split('/').pop()
    const filepath = helper.getUploadPath(type, filename)
    if (!helper.checkFileExists(filepath)) {
      return
    }
    helper.deleteFile(filepath)
  } catch (err) {
    console.log('deleteUploadFile is error', err)
  }
}

helper.getUploadFileName = (fileurl) => {
  return fileurl ? fileurl.split('/').pop() : ''
}

helper.getUploadUrl = (type, fileName) => {
  try {
    return `${config.upload.path}${type}/${fileName}`
  } catch (err) {
    console.log('getUploadUrl is error', err)
    return ''
  }
}

helper.moveFile = async (original, target) => {
  try {
    if (!original || !target) {
      return
    }
    await mv(original, target)
  } catch (err) {
    console.log('moveFile is error', err)
  }
}

helper.moveUploadFile = async (type, fileName) => {
  try {
    if (!type || !fileName) return
    const newOriginal = helper.getUploadPath('tmp', fileName)
    const newTarget = helper.getUploadPath(type, fileName)
    helper.moveFile(newOriginal, newTarget)
  } catch (err) {
    console.log('moveUploadFile is error', err)
  }
}

helper.isValidObjectId = (id) => {
  if (!id || id.length != 24) {
    return false
  }
  return true
}

module.exports = helper