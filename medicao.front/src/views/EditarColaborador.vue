<template>
    <section>
        <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
        <div class="hero-body">
            <div class="container has-text-centered">
                <h1 class="title">
                    Atualização de cadastro
                </h1>
                <h2 class="subtitle">
                    Editar colaborador
                </h2>
            </div>
        </div>
        <div class="columns">
            <div class="column is-1"></div>
            <div class="column is-4">
                <div class="card">
                    <div class="card-image">
                        <figure class="image is-4by3">
                            <img src="https://bulma.io/images/placeholders/1280x960.png" alt="Placeholder image">
                        </figure>
                    </div>
                    <div class="card-content">
                        <div class="media">
                            <div class="media-content">
                                <p class="title is-4">John Smith</p>
                                <p class="subtitle is-6">@johnsmith</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="column is-2"></div>
            <div class="column is-4">
                <b-field label="Id" class="pt-5">
                    <b-input v-model="pessoa.id" disabled></b-input>
                </b-field>
                <b-field label="Nome" class="pt-5">
                    <b-input v-model="pessoa.nome"></b-input>
                </b-field>
                <b-field label="Sobrenome" class="pt-5">
                    <b-input v-model="pessoa.sobrenome"></b-input>
                </b-field>
                <b-field label="E-mail" class="pt-5">
                    <b-input v-model="pessoa.email"></b-input>
                </b-field>
                <b-field label="Setor" class="pt-5">
                    <b-input v-model="pessoa.setor"></b-input>
                </b-field>
            </div>
        </div>
        <div class="container has-text-centered">
            <b-button class="mt-4" icon-left="account-plus" type="is-primary" @click="alterarPessoa">Salvar Alterações</b-button>
        </div>    
    </section>
</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      isLoading: false,
      pessoaid: '',
      pessoa: {
        nome: '',
        sobrenome: '',
        setor: '',
      }
    }
  },
  mounted () {
    this.isLoading = true
    this.pessoaid = this.$route.params.id
    axios.get('http://localhost:5000/api/pessoa/' + this.pessoaid).then(ret => {
      this.pessoa = ret.data
      this.isLoading = false
    }).catch(() => {
      this.isLoading = false
      this.$buefy.toast.open({
        message: 'pessoa não encontrada.',
        type: 'is-danger'
      })
      this.$router.push('/')
    })
  },
  methods: {
    alterarPessoa () {
      this.isLoading = true

      axios.put('http://localhost:5000/api/pessoa/' + this.pessoaid, this.pessoa).then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Pessoa alterada com sucesso.',
          type: 'is-success'
        })
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao alterar a pesosa.',
          type: 'is-danger'
        })
      })
    }
  }
}
</script>
<style scoped>
.columns{
    margin-top: 5%;
    margin-bottom: 15%;
    min-height: 100px;
  }
  .level-left{
    margin: 1%;
  }
</style>