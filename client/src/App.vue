<template>
  <div style="background-color: rgb(47, 47, 47);">
    <div class="ui inverted segment navbar">
      <div class="ui center aligned container">
        <div class="ui large secondary inverted pointing menu compact">
          <router-link to="/tasks" class="item">
            <i class="list icon"></i>Tasks
          </router-link>
          <router-link to="/tasks/new" class="item">
            <i class="plus icon"></i>New
          </router-link>
        </div>
      </div>
    </div>

    <div class="ui container">
      <div class="ui grid">
        <div class="row">
          <div class="twelve wide column">
            <router-view />
          </div>
          <div class="four wide column">
            <flash-message></flash-message>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>
