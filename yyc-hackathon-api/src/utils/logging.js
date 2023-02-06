const chalk = require('chalk')

const logging = {}

logging.log = (args) => this.info(args)
logging.info = (args) => console.log(chalk.blue(`[${new Date().toLocaleString()}] [INFO]`), typeof args === 'string' ? chalk.blueBright(args) : args)
logging.warning = (args) => console.log(chalk.yellow(`[${new Date().toLocaleString()}] [WARN]`), typeof args === 'string' ? chalk.yellowBright(args) : args)
logging.error = (args) => console.log(chalk.red(`[${new Date().toLocaleString()}] [ERROR]`), typeof args === 'string' ? chalk.redBright(args) : args)

module.exports = logging