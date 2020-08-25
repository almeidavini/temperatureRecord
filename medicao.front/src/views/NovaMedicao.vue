<template>
  <section>
    <div class="columns">
      <!--<div class="column is-1"></div>-->
      <div class="column">
        <nav class="panel">
          <p class="panel-heading level">
            Cadastro de medição
          </p>
          <div>
          <div class="level-left">
              <b-button type="is-info mr-3" @click="getPessoas" icon-left="refresh">Atualizar</b-button>
          </div>
          <div class="level-r"></div>
          </div>
          <b-table :data="pessoas" focusable>
            <template slot-scope="props">
              <b-table-column
                field="nome"
                label="Nome"
                sortable 
                centered>
                {{props.row.nome}}
              </b-table-column>
              <b-table-column
                field="sobrenome"
                label="Sobrenome"
                centered>
                {{props.row.sobrenome}}
              </b-table-column>
              <b-table-column
                field="email"
                label="Email"
                centered>
                {{props.row.email}}
              </b-table-column>
              <b-table-column
                field="setor"
                label="Setor"
                sortable
                centered>
                {{props.row.setor.nome}}
              </b-table-column>
              <b-table-column
                field="acoes"
                label="Ações"
                centered>
                <b-button type="is-success mr-1" icon-left="thermometer-plus" tag="router-link" :to="'/medicaocolaborador/' + props.row.id">Medição</b-button>
              </b-table-column>
            </template>
            <template slot="empty">
                <section class="section">
                    <div class="content has-text-grey has-text-centered">
                        <p>
                            <b-icon
                                icon="emoticon-sad"
                                size="is-large">
                            </b-icon>
                        </p>
                        <p>Ainda não temos colaboradores cadastrados.</p>
                    </div>
                </section>
            </template>
          </b-table>
        </nav>
      </div>
    </div>
  </section>
</template>

<script>
import axios from 'axios'
export default {
  data () {
    return {
      pessoas: [],
      columns: [
        { field: 'nome', label: 'Nome' },
        { field: 'sobrenome', label: 'Sobrenome' },
        { field: 'setor', label: 'Setor' },
        { field: 'email', label: 'Email'}
      ]
    }
  },
  methods: {
    getPessoas () {
      axios.get('http://localhost:5000/api/pessoa').then(ret => {
        this.pessoas = ret.data
      })
    }
  },
  mounted () {
    this.getPessoas()
  }
}
</script>

<style scoped>
  .panel{
    margin-top: 5%;
    min-height: 100px;
  }
  .level-left{
    margin: 1%;
  }
  .column{
    margin-right: 5%;
    margin-left: 5%;
  }
</style>
