<template>
  <div id="app">
    <ContactForm />
  </div>
</template>

<script>
import ContactForm from './components/ContactForm.vue';

export default {
  name: 'App',
  components: {
    ContactForm
  }
}
</script>

<style>
:root {
    --blue: #0087AA;
    --white: #FFFFFF;
    --text: #4A4A4A;
}

#app {
  font-family: Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: var(--text);
  margin-top: 60px;
  background: #f5f5f5;
}
</style>
