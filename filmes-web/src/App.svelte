<script lang="ts">
  import axios, { type AxiosResponse } from 'axios';
  
  let newTitle = '';
  let newGenre = '';
  let newDuration = '';

  let skip = 0;
  let take = 5;

  let getId = 1;

  let editId = 1;
  let editTitle = '';
  let editGenre = '';
  let editDuration = '';

  let deleteId = 1;

  let currentResponse: AxiosResponse<any, any>;

  const api = axios.create({
    baseURL: 'http://localhost:5260'
  });

  async function handleCreate() {
    try {
      const response = await api.post('/filme', {
        titulo: newTitle,
        genero: newGenre,
        duracao: Number(newDuration),
      });

      currentResponse = response;
    } catch (error) {
      currentResponse = error.response;
    }
  }

  async function handleRead() {
    try {
      const response = await api.get('/filme', {
        params: {
          skip: Number(skip),
          take: Number(take),
        }
      });

      currentResponse = response;
    } catch (error) {
      currentResponse = error.response;
    }
  }

  async function handleGetById() {
    try {
      const response = await api.get(`/filme/${getId}`);

      currentResponse = response;
    } catch (error) {
      currentResponse = error.response;
    }
  }

  async function handleUpdate() {
    try {
      const response = await api.put(`/filme/${editId}`, {
        titulo: editTitle,
        genero: editGenre,
        duracao: Number(editDuration),
      });

      currentResponse = response;
    } catch (error) {
      currentResponse = error.response;
    }
  }

  async function handleDelete() {
    try {
      const response = await api.delete(`/filme/${deleteId}`);

      currentResponse = response;
    } catch (error) {
      currentResponse = error.response;
    }
  }
</script>

<h1>Filmes API</h1>

<main>
  <div class="crud">
    <section>
      <h2>Inserir filme</h2>

      <form on:submit|preventDefault={() => handleCreate()}>
        <div>
          <label for="title"> Título </label>
          <input type="text" id="title" name="title" bind:value={newTitle} />
        </div>

        <div>
          <label for="genre"> Gênero </label>
          <input type="text" id="genre" name="genre" bind:value={newGenre} />
        </div>

        <div>
          <label for="duration"> Duração </label>
          <input
            type="number"
            id="duration"
            name="duration"
            bind:value={newDuration}
          />
        </div>

        <button type="submit"> Inserir </button>
      </form>
    </section>

    <section>
      <h2>Listagem de filmes</h2>

      <form on:submit|preventDefault={() => handleRead()}>
        <div>
          <label for="skip"> A partir de </label>
          <input type="number" id="skip" name="skip" bind:value={skip} />
        </div>

        <div>
          <label for="take"> A partir de </label>
          <input type="number" id="take" name="take" bind:value={take} />
        </div>

        <button type="submit"> Listar </button>
      </form>
    </section>

    <section>
      <h2>Busca de filmes por id</h2>

      <form on:submit|preventDefault={() => handleGetById()}>
        <div>
          <label for="id"> Id </label>
          <input type="number" id="id" name="id" bind:value={getId} />
        </div>

        <button type="submit"> Buscar </button>
      </form>
    </section>

    <section>
      <h2>Editar filme</h2>

      <form on:submit|preventDefault={() => handleUpdate()}>
        <div>
          <label for="id"> Id </label>
          <input type="number" id="id" name="id" bind:value={editId} />
        </div>

        <div>
          <label for="title"> Título </label>
          <input type="text" id="title" name="title" bind:value={editTitle} />
        </div>

        <div>
          <label for="genre"> Gênero </label>
          <input type="text" id="genre" name="genre" bind:value={editGenre} />
        </div>

        <div>
          <label for="duration"> Duração </label>
          <input
            type="number"
            id="duration"
            name="duration"
            bind:value={editDuration}
          />
        </div>

        <button type="submit"> Editar </button>
      </form>
    </section>

    <section>
      <h2>Deletar filme</h2>

      <form on:submit|preventDefault={() => handleDelete()}>
        <div>
          <label for="id"> Id </label>
          <input type="number" id="id" name="id" bind:value={deleteId} />
        </div>

        <button type="submit"> Deletar </button>
      </form>
    </section>
  </div>

  <div class="responses">
    <h2>Respostas das requisições</h2>

    <span>
      Código: {`${currentResponse?.status} - ${currentResponse?.statusText}` ||
        ""}
    </span>
    <pre>
      {JSON.stringify(currentResponse?.data, null, 2)}
    </pre>
  </div>
</main>

<style>
  h1 {
    margin-top: 0;
  }

  main {
    display: flex;
    flex-direction: row;
    gap: 2.4rem;
  }

  .crud {
    flex: 1 1 0%;
  }

  form {
    display: flex;
    flex-direction: row;
    gap: 2.4rem;
  }

  pre {
    background-color: grey;
    color: white;
  }
</style>
