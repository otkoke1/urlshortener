const router = (app) => {
   const TaskController = require('../controllers/taskController')

   app.route('/tasks')
      .get(TaskController.view_all_task)
      .post(TaskController.add_task)
      .delete(TaskController.delete_all_task)

   app.route('/tasks/:id')
      .get(TaskController.view_a_task)
      .put(TaskController.update_task)
      .delete(TaskController.delete_a_task)
}

module.exports = router