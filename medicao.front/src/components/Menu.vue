<template>
  <div id="menu">
        <b-navbar type="is-info">
        <template slot="brand">
            <b-navbar-item tag="router-link" :to="{ path: '/' }">
                <img src="../assets/logo.png" alt="Serget">
            </b-navbar-item>
            <b-navbar-item>
                <strong>Sistema de medição</strong>
            </b-navbar-item>
        </template>
        <template slot="end">
                <b-navbar-item tag="router-link" to="/buscarmedicao">
                    Medições
                </b-navbar-item>
                <b-navbar-item tag="router-link" to="/colaboradores">
                    Colaboradores
                </b-navbar-item>
                <b-navbar-item tag="div">
                <div class="buttons">
                    <a class="button is-light">
                        Sair
                    </a>
                </div>
            </b-navbar-item>
        </template>
    </b-navbar>
    <router-view/>
  </div>
</template>

<script>

export default {
  name: 'Menu',
  components: {
  }
}
</script>

<style>
img{
    width: 50px;
}
</style>