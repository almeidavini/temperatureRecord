<template>
    <section>
        <div class="columns">
          <div class="column is-1"></div>
          <div class="column is-10">
            <div class="hero is-primary is-bold">
                <div class="container has-text-centered">
                    <h1 class="title">
                        Cadastro de colaborador
                    </h1>
                    <h2 class="subtitle">
                        Novo colaborador
                    </h2>
                </div>
            </div>
          </div>
        </div>
        <div class="columns">
          <div class="column is-1"></div>
          <div class="column is-4">
            <b-field label="Nome" class="pt-5">
              <b-input v-model="pessoa.nome"></b-input>
            </b-field>
            <b-field label="Sobrenome">
              <b-input v-model="pessoa.sobrenome"></b-input>
            </b-field>
            <b-field label="E-mail">
              <b-input v-model="pessoa.email"></b-input>
            </b-field>
            <b-field label="Setor">
              <b-autocomplete rounded
                v-model="setor"
                :data="filteredDataSetor"
                field="nome"
                placeholder="Selecione o setor"
                icon="magnify"
                clearable
                @select="option => selectedSetor = option.id">
                  <template slot="empty">
                    No results found
                  </template>
              </b-autocomplete>
            </b-field>
          </div>
          <div class="column is-2"></div>
          <div class="column is-4" id="upload">
            <b-field>
              <b-upload v-model="dropFiles"
                multiple
                drag-drop>
                <section class="section">
                  <div class="content has-text-centered">
                    <p>
                      <b-icon
                        icon="upload"
                        size="is-large">
                      </b-icon>
                    </p>
                    <p>Solte ou clique aqui para enviar a imagem de perfil</p>
                  </div>
                </section>
              </b-upload>
            </b-field>
          </div>
        </div>
        <div class="container has-text-centered" id="button">
          <b-button class="mt-4" icon-left="account-plus" type="is-twitter" @click="adicionarPessoa">Cadastrar colaborador</b-button>
        </div>    
    </section>
</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      isLoading: false,
      pessoa: {
        nome: '',
        sobrenome: '',
        email: '',
        setorId: 0,
      },
      setores: [],
      setor: '',
      selected: null,
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
    this.getSetores()
  },
  methods: {
    adicionarPessoa () {
      this.isLoading = true

      if (this.selectedSetor != null) {
        this.pessoa.setorId = parseInt(this.selectedSetor)
      }

      this.pessoa.setor = null

      axios.post('http://localhost:5000/api/pessoa', this.pessoa).then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Pessoa adicionada com sucesso.',
          type: 'is-success'
        })
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao adicionar a pesosa.',
          type: 'is-error'
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
  #upload{
    margin-top: 8%;
  }
</style>