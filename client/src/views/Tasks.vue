<template>
  <div>
    <table class="task-table">
      <thead>
        <tr>
          <th colspan="5">TASK LIST</th>
        </tr>
        <tr>
          <th>To Dos</th>
          <th>Description</th>
          <th colspan="3">Menu</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(task, i) in tasks" :key="i">
          <td>{{ task.todo }}</td>
          <td>{{ task.desc }}</td>
          <td>
            <router-link
              class="ui button green"
              :to="{ name: 'Show', params: { id: task._id } }"
            >
              Show
            </router-link>
          </td>
          <td>
            <router-link
              class="ui button yellow"
              :to="{ name: 'Edit', params: { id: task._id } }"
            >
              Edit
            </router-link>
          </td>
          <td>
            <a class="ui button red" @click.prevent="onDelete(task._id)">
              Delete
            </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { ViewAllTasks, DeleteTask } from "../helpers/api";

export default {
  name: "Tasks",
  data() {
    return {
      tasks: [],
    };
  },
  async mounted() {
    this.tasks = await ViewAllTasks();
  },
  methods: {
    async onDelete(id) {
      //1. display confirm message before deletion
      const deleteConfirm = window.confirm(
        "Are you sure to delete this task ?"
      );
      if (deleteConfirm) {
        //2. delete task from database
        await DeleteTask(id);
        //3. refresh the task list (remove deleted tasks)
        const updatedTasks = this.tasks.filter((task) => task._id !== id);
        this.tasks = updatedTasks;
        //4. display flash message after deletion
        this.flash("Delete task succeed !");
      }
    },
  },
};
</script>

<style>
      .task-table {
        overflow-x: auto;
        border-collapse: collapse; /* Ensure no space between cells */
      }
      .task-table td, .task-table th {
        padding: 10px 20px 10px 20px;
        border: 1px solid gray; /* Default border for all cells */
      }
      /* Remove the right border from the middle column */
      .task-table td:nth-child(3), td:nth-child(4), td:nth-child(5) {
        padding:  10px 0 10px 0;
        border-right: none;
        border-left: none;
      }
      .task-table td:nth-child(5) {
        padding:  10px 20px 10px 0;
        border-right: 1px solid gray;
      }
      .task-table td:nth-child(3) {
        padding:  10px 0 10px 20px;
      }
      .task-table td:nth-child(2) {
        width: 400px;
      }
</style>