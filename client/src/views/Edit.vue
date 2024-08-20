<template>
  <div>
    <h1>Edit Task</h1>
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
import { ViewTaskById, UpdateTask } from "../helpers/api";
export default {
  name: "Edit",
  data() {
    return {
      task: {},
    };
  },
  async mounted() {
    this.task = await ViewTaskById(this.$route.params.id);
  },
  methods: {
     onSubmit: async function () {
        //1. update database
         await UpdateTask(this.$route.params.id, this.task)
        //2. display message
        this.flash("Edit task succeed !")
        //3. redirect page
        this.$router.push("/tasks")
    },
  },
};
</script>
