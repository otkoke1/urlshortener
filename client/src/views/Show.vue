<template>
  <div>
    <h1>Show Task</h1>
    <div class="ui labeled input fluid">
      <div class="ui label">To Do</div>
      <input type="text" disabled :value="task.todo" style="background-color: gray;"/>
    </div>
    <br />
    <div class="ui labeled input fluid">
      <div class="ui label">Description</div>
      <input type="text" disabled :value="task.desc" style="background-color: gray;"/>
    </div>
    <br />
    <div>
      <router-link
        :to="{ name: 'Edit', params: { id: this.$route.params.id } }"
        class="ui yellow button"
      >
        Edit Task
      </router-link>
    </div>
  </div>
</template>

<script>
import { ViewTaskById } from '../helpers/api';
export default {
  name: "Show",
  data() {
    return {
      task: "",
    };
  },
  async mounted() {
    this.task = await ViewTaskById(this.$route.params.id);
  },
};