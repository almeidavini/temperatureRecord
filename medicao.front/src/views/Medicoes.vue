<template>
  <section>
    <div class="columns">
      <div class="column is-1"></div>
      <div class="column">
        <nav class="panel">
          <p class="panel-heading level">
            Medições
          </p>
          <div>
          <div class="level-left">
              <b-button type="is-info mr-3" @click="getMedicoes" icon-left="refresh">Atualizar</b-button>
              <b-button type="is-info" tag="router-link" to="/novocolaborador" icon-left="account-plus">Novo</b-button>
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
                {{props.row.pessoas.nome}}
              </b-table-column>
              <b-table-column
                field="sobrenome"
                label="Sobrenome"
                centered>
                {{props.row.pessoas.sobrenome}}
              </b-table-column>
              <b-table-column
                field="setor"
                label="Setor"
                sortable
                centered>
                {{props.row.setor.nome}}
              </b-table-column>
              <b-table-column
                field="temperatura"
                label="Temperatura"
                centered>
                {{props.row.temperatura}}
              </b-table-column>
              <b-table-column
                field="acoes"
                label="Ações"
                centered>
                <b-button type="is-danger" icon-left="delete" @click="deleteMedicao(props.row.id)">Excluir</b-button>
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
                        <p>Ainda não temos medições cadastradas.</p>
                    </div>
                </section>
            </template>
          </b-table>
        </nav>
      </div>
      <div class="column is-1"></div>
    </div>
  </section>
</template>

<script>
import axios from 'axios'
export default {
  data () {
    return {
      medicoes: [],
      columns: [
        { field: 'nome', label: 'Nome' },
        { field: 'sobrenome', label: 'Sobrenome' },
        { field: 'setor', label: 'Setor' },
        { field: 'temperatura', label: 'Temperatura'}
      ]
    }
  },
  methods: {
    getMedicoes () {
      axios.get('http://localhost:5000/api/medicao').then(ret => {
        this.pessoas = ret.data
      })
    },
    deleteMedicao (id) {
      axios.delete('http://localhost:5000/api/medicao/' + id).then(() => {
        this.$buefy.toast.open({
          message: 'Medição deletada com sucesso.',
          type: 'is-success'
        })
        this.getMedicoes()
      }).catch(() => {
        this.$buefy.toast.open({
          message: 'erro ao deletar medição.',
          type: 'is-danger'
        })
      })
    },
  mounted () {
    this.getMedicoes()
  }
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
</style>
