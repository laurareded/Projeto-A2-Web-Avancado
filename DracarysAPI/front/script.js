document.addEventListener("DOMContentLoaded", () => {
    const base = "http://localhost:5234/api"; 
  
    const schemas = {
      casa: {
        labelSingular: "Casa",
        labelPlural: "Casas",
        fields: [
          { name: "nome", label: "Nome", type: "text" },
          { name: "region", label: "Região", type: "text" }
        ]
      },
      personagem: {
        labelSingular: "Personagem",
        labelPlural: "Personagens",
        fields: [
          { name: "nome", label: "Nome", type: "text" },
          { name: "casaId", label: "ID da Casa", type: "number" }
        ]
      },
      dragao: {
        labelSingular: "Dragão",
        labelPlural: "Dragões",
        fields: [
          { name: "nome", label: "Nome", type: "text" },
          { name: "montador", label: "Montador", type: "text" },
          { name: "casaId", label: "ID da Casa", type: "number" }
        ]
      }
    };
  
    function renderForm(entity) {
      const schema = schemas[entity];
      let html = `<h2>Cadastrar ${schema.labelSingular}</h2>`;
      schema.fields.forEach(f => {
        html += `
          <label for="${f.name}">${f.label}:</label>
          <input id="${f.name}" type="${f.type}" />`;
      });
      html += `<button id="btn-cadastrar">Cadastrar ${schema.labelSingular}</button>`;
      document.getElementById("form-section").innerHTML = html;
      document.getElementById("entity-list-label").textContent = schema.labelPlural;
  
      document
        .getElementById("btn-cadastrar")
        .addEventListener("click", async () => {
          const payload = {};
          schema.fields.forEach(f => {
            const val = document.getElementById(f.name).value;
            payload[f.name] = f.type === "number" ? Number(val) : val;
          });
          try {
            const entityRoute = entity.charAt(0).toUpperCase() + entity.slice(1);
            await fetch(`${base}/${entityRoute}`, {
              method: "POST",
              headers: { "Content-Type": "application/json" },
              body: JSON.stringify(payload)
            });
            alert(`${schema.labelSingular} cadastrado com sucesso!`);
            renderForm(entity);
            listarEntidades(entity);
          } catch {
            alert(`Erro ao cadastrar ${schema.labelSingular}!`);
          }
        });
    }
  
    async function listarEntidades(entity) {
      const schema = schemas[entity];
      const entityRoute = entity.charAt(0).toUpperCase() + entity.slice(1);
      try {
        const res = await fetch(`${base}/${entityRoute}`);
        if (!res.ok) throw new Error();
        const data = await res.json();
        const listEl = document.getElementById("listagem");
        listEl.innerHTML = "";
        data.forEach(item => {
          let text = `ID: ${item.id}`;
          schema.fields.forEach(f => {
            text += ` • ${f.label}: ${item[f.name]}`;
          });
          const li = document.createElement("li");
          li.textContent = text;
          listEl.appendChild(li);
        });
      } catch {
        alert(`Erro ao buscar ${schema.labelPlural}!`);
      }
    }
});
