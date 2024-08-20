const taskModel = require('../models/taskModel')

const view_all_task = async (req, res) => {
   try {
      //sort by _id descending => new tasks display first (on the top)
      tasks = await taskModel.find({}).sort({ _id: -1 })
      res.json(tasks)
   } catch (err) {
      res.send(err)
   }
}

const view_a_task = async (req, res) => {
   try {
      id = req.params.id
      task = await taskModel.findById(id)
      res.json(task)
   } catch (err) {
      res.send(err)
   }
}

const delete_a_task = async (req, res) => {
   try {
      id = req.params.id
      await taskModel.findByIdAndDelete(id)
      //await taskModel.deleteOne(id)
      res.json({ message : "Delete a task succeed !"})
   } catch (err) {
      res.send(err)
   }
}

const delete_all_task = async (req, res) => {
   try {
      await taskModel.deleteMany()
      res.json({ message: "Delete all tasks succeed !" })
   } catch (err) {
      res.send(err)
   }
}

const add_task = async (req, res) => {
   try {
      task = req.body
      await taskModel.create(task)
      //await taskModel.save(task)
      res.json({ message: "Add new task succeed !" })
   } catch (err) {
      res.send(err)
   }
}

const update_task = async (req, res) => {
   try {
      id = req.params.id
      task = req.body
      await taskModel.findByIdAndUpdate(id, task)
      //await taskModel.findOneAndUpdate(id, task)
      res.json({ message: "Update task succeed !" })
   } catch (err) {
      res.send(err)
   }
}

module.exports = {
   view_all_task,
   add_task,
   view_a_task,
   update_task,
   delete_all_task,
   delete_a_task
}