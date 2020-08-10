<template>
    <section>
        <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
        <div class="columns">
          <div class="column is-1"></div>
          <div class="column is-10">
            <div class="hero is-primary is-bold">
                <div class="container has-text-centered">
                    <h1 class="title">
                        Atualização de cadastro
                    </h1>
                    <h2 class="subtitle">
                        Editar colaborador
                    </h2>
                </div>
            </div>
          </div>
        </div>
        <div class="columns">
            <div class="column is-1"></div>
            <div class="column is-4">
                <div class="card">
                    <div class="card-image">
                        <figure class="image is-4by3">
                            <img src="../assets/profile.jpeg" alt="Placeholder image">
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
              <div class="field">
                <b-field label="Número de identificação" class="pt-2">
                    <b-input v-model="pessoa.id" disabled></b-input>
                </b-field>
              </div>
              <div class="field">
                <b-field label="Nome" class="pt-2">
                    <b-input v-model="pessoa.nome"></b-input>
                </b-field>
              </div>
                <div class="field">
                <b-field label="Sobrenome" class="pt-2">
                    <b-input v-model="pessoa.sobrenome"></b-input>
                </b-field>
                </div>
                <div class="field">
                <b-field label="E-mail" class="pt-2">
                    <b-input v-model="pessoa.email"></b-input>
                </b-field>
                </div>
                <div class="field">
                  <b-field label="Setor">
                    <b-autocomplete rounded
                                    v-model="setor"
                                    :data="filteredDataSetor"
                                    field="nome"
                                    placeholder="Selecione o exame"
                                    icon="magnify"
                                    clearable
                                    @select="option => selectedSetor = option.id">
                      <template slot="empty">
                        No results found
                      </template>
                    </b-autocomplete>
                  </b-field>
                </div>
            </div>
        </div>
        <div class="container has-text-centered" id="button">
            <b-button class="mt-4" icon-left="account-check" type="is-twitter" @click="alterarPessoa">Salvar Alterações</b-button>
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
        email: '',
        setorId: 0
      },
      setores: [],
      setor: '',
      selectedSetor: null
    }
  },
  computed: {
    filteredDataSetor () {
      return this.setores.filter((option) => {
        return option.nome
          .toString()
          .toLowerCase()
          .indexOf(this.setor.toLowerCase()) >= 0
      })
    }
  },
  mounted () {
    this.isLoading = true
    this.pessoaid = this.$route.params.id
    axios.get('http://localhost:5000/api/pessoa/' + this.pessoaid).then(ret => {
      this.pessoa = ret.data
      this.setor = this.pessoa.setor.nome
      this.isLoading = false
    }).catch(() => {
      this.isLoading = false
      this.$buefy.toast.open({
        message: 'pessoa não encontrada.',
        type: 'is-danger'
      })
      this.$router.push('/')
    }),
    this.getSetores()
  },
  methods: {
    alterarPessoa () {
      this.isLoading = true

      if (this.selectedSetor != null) {
        this.pessoa.setorId = parseInt(this.selectedSetor)
      }

      this.pessoa.setor = null
      
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
    },
    getSetores () {
      axios.get('http://localhost:5000/api/setor').then(ret => {
        this.setores = ret.data
      })
    }
  }
}
</script>
<style scoped>
.columns{
    margin-top: 5%;
    margin-bottom: 5%;
    min-height: 100px;
  }
  .level-left{
    margin: 1%;
  }
  #button{
    margin-bottom: 5%;
  }
  .hero{
    border-radius: 4px;
    padding: 2px;
  }
</style>