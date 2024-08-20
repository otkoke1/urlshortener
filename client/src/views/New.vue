<template>
  <div>
    <h1>New Task</h1>
    <form action="" @submit.prevent="onSubmit">
      <div class="ui labeled input fluid">
        <div class="ui label">To Do</div>
        <input type="text" required v-model="task.todo" style="background-color: gray;"/>
      </div>
      <br />
      <div class="ui labeled input fluid">
        <div class="ui label">Description</div>
        <input type="text" required v-model="task.desc" style="background-color: gray;"/>
      </div>
      <br />
      <button class="ui primary button">Submit</button>
    </form>
  </div>
</template>

<script>
import { AddNewTask } from "../helpers/api";
export default {
  name: "New",
  data() {
    return {
      task: {},
    };
  },
  methods: {
    onSubmit: async function () {
      //1. add new task to database using axios
      await AddNewTask(this.task);
      //2. display succeed message using vue-flash
      this.flash("Add new task succeed !");
      //3. redirect to task list using $router
      this.$router.push("/tasks");
    },
  },
};
</script>
