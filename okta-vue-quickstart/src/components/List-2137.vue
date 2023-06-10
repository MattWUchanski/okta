<template>
    <div>
      <input v-model="newTask" @keyup.enter="addTask">
      <ul>
        <li v-for="task in tasks" :key="task.id">
          <input type="checkbox" v-model="task.isComplete" @change="updateTask(task)">
          {{ task.description }}
          <button @click="deleteTask(task)">Delete</button>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        newTask: '',
        tasks: [],
      };
    },
    async created() {
      const response = await axios.get('https://localhost:5001/api/Task2137');
      this.tasks = response.data;
    },
    methods: {
      async addTask() {
        const response = await axios.post('https://localhost:5001/api/Task2137', {
          description: this.newTask,
          isComplete: false,
        });
        this.tasks.push(response.data);
        this.newTask = '';
      },
      async updateTask(task) {
        await axios.put(`https://localhost:5001/api/Task2137/${task.id}`, task);
      },
      async deleteTask(task) {
        await axios.delete(`https://localhost:5001/api/Task2137/${task.id}`);
        this.tasks = this.tasks.filter(t => t.id !== task.id);
      },
    },
  };
  </script>
  