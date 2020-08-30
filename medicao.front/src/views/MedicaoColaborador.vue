<template>
    <section>
        <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
        <div class="columns">
          <div class="column is-1"></div>
          <div class="column is-10">
            <div class="hero is-primary is-bold">
                <div class="container has-text-centered">
                    <h1 class="title">
                      Cadastro de medição
                    </h1>
                    <h2 class="subtitle">
                      Medição de temperatura
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
                                <p class="title is-4">{{pessoa.nome + " " + pessoa.sobrenome}}</p>
                                <label class="subtitle is-6">{{pessoa.email}}</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="column is-2"></div>
            <div class="column is-4">
              <div class="field">
                <b-field label="Número de identificação:" class="pt-2">
                    <b-label>{{pessoa.id}}</b-label>
                </b-field>
              </div>
              <div class="field">
                <b-field label="Nome:" class="pt-2">
                    <b-label>{{pessoa.nome}}</b-label>
                </b-field>
              </div>
                <div class="field">
                <b-field label="Sobrenome:" class="pt-2">
                    <b-label>{{pessoa.sobrenome}}</b-label>
                </b-field>
                </div>
                <div class="field">
                <b-field label="E-mail:" class="pt-2">
                    <b-label>{{pessoa.email}}</b-label>
                </b-field>
                </div>
                <div class="field">
                  <b-field label="Setor:" class="pt-2">
                    <b-label>{{setor}}</b-label>
                  </b-field>
                </div>
                <div class="field">
                  <b-field label="Data:" class="pt-2">
                    <b-label>{{data}}</b-label>
                  </b-field>
                </div>
                <div class="field">
                  <b-field label="Hora:" class="pt-2">
                    <b-label>{{hora}}</b-label>
                  </b-field>
                </div>
                 <div class="field">
                  <b-field label="Temperatura:" class="pt-2">
                    <b-input v-model="medicao.temperatura" placeholder="Digite a temperatura aferida"></b-input>
                  </b-field>
                </div>
            </div>
        </div>
        <div class="container has-text-centered" id="button">
            <b-button class="mt-4" icon-left="thermometer-plus" type="is-twitter" @click="adicionarMedicao">Cadastrar Medição</b-button>
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
       medicao: {
        temperatura: '',
        pessoaId: '',
        dtMedicao: ''
      },
      setores: [],
      setor: '',
      data: '',
      hora: ''
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
    })
    var dataHora = new Date();
    var dd = String(dataHora.getDate()).padStart(2, '0');
    var mm = String(dataHora.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = dataHora.getFullYear();
    var h = dataHora.getHours();
    var m = dataHora.getMinutes();
    this.data = dd + '/ ' + mm + '/ ' + yyyy;
    this.hora = h + ':' + m
  },
  methods: {
    adicionarMedicao () {
      this.medicao.temperatura = parseFloat(this.medicao.temperatura);
      this.medicao.pessoaId = this.pessoa.id;
      var today = new Date();
      var dd = String(today.getDate()).padStart(2, '0');
      var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
      var yyyy = today.getFullYear();
      this.medicao.dtMedicao = yyyy + '-' + mm + '-' + dd + 'T' + String(today.getHours()) + ':' + String(today.getMinutes()) + ':' + String(today.getSeconds());
      this.isLoading = true
      axios.post('http://localhost:5000/api/medicao', this.medicao).then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Medicao adicionada com sucesso.',
          type: 'is-success'
        })
        console.log(this.medicao);
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao adicionar a medição.',
          type: 'is-error'
        })
        console.log(this.medicao);
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