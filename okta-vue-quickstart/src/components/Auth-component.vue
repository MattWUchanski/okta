<template>
    <ul v-if="posts && posts.length">
      <li v-for="post in posts" :key='post.Id'>
        <p><strong>{{post.title}}</strong></p>
      <p>{{post.content}}</p>
      </li>
    </ul>
  </template>
  
  <script>
  import axios from 'axios'
  
  export default {
    data () {
      return {
        posts: []
      }
    },
    async created () {
      axios.defaults.headers.common['Authorization'] = `Bearer ${this.$auth.getAccessToken()}`
      try {
        const response = await axios.get(`https://localhost:5001/api/posts`)
        this.posts = response.data
      } catch (e) {
        console.error(`Errors! ${e}`)
      }
    }
  }
  </script>
  