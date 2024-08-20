const mongoose = require('mongoose')
const taskSchema = mongoose.Schema(
   {
      todo: {
         type: String,
         required: "Task can not be empty"
      },
      desc: {
         type: String,
         required: "Description can not be empty"
      }
   },
   {
      versionKey: false  //ignore version key for new data
   }
)
const taskModel = mongoose.model('tasks', taskSchema)
//tasks: collection (table) name
module.exports = taskModel