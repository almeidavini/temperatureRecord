<template>
  <div id="menu">
    <b-navbar type="is-info">
        <template slot="brand">
            <b-navbar-item tag="router-link" :to="{ path: '/' }">
                <img src="../assets/logo.png" alt="Serget">
            </b-navbar-item>
            <b-navbar-item tag="router-link" :to="{ path: '/' }">
                <strong>SISTEMA DE MEDIÇÃO</strong>
            </b-navbar-item>
        </template>
        <template slot="end">
            <b-navbar-item tag="router-link" to="/medicoes">
                    Medições
                </b-navbar-item>
                <b-navbar-item tag="router-link" to="/colaboradores">
                    Colaboradores
                </b-navbar-item>
                <b-navbar-item tag="div">
                <b-button icon-left="power">Sair</b-button>
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