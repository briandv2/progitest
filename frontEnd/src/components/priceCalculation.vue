<template>
  <div class="container mt-5">
    <form @submit.prevent="submitForm">
      <div class="form-group">
        <label for="basePrice">vehicle base price</label>
        <input type="text" class="form-control" id="basePrice" v-model="basePrice" required />
      </div>
      <div class="form-group">
        <label for="vehicleType">Vehicle type</label>
        <select class="form-control" id="vehicleType" v-model="vehicleType" required>
          <option v-for="option in options" :key="option.value" :value="option.value">
            {{ option.text }}
          </option>
        </select>
      </div>
      <br />
      <button type="submit" class="btn btn-primary">Enviar</button>
    </form>
    <br />
    <br />
    <div v-if="price">
      <table class="table">
        <thead>
          <tr>
            <th scope="col">Basic</th>
            <th scope="col">Special</th>
            <th scope="col">Association</th>
            <th scope="col">Storage</th>
            <th scope="col">Total</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th>{{ price.basic }}</th>
            <td>{{ price.special }}</td>
            <td>{{ price.association }}</td>
            <td>{{ price.storage }}</td>
            <td>{{ price.total }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "PriceCalculation",
  data() {
    return {
      basePrice: "",
      vehicleType: "",
      options: [
        { value: 1, text: "common" },
        { value: 2, text: "Luxury" },
      ],
      price: null,
    };
  },
  methods: {
    async submitForm() {
      try {
        const response = await axios.post("https://localhost:7121/CalculatePrice/Post", {
          price: this.basePrice,
          vehicleType: this.vehicleType,
        });
        this.price = response.data;
      } catch (error) {
        console.error("Error al enviar el formulario:", error);
      }
    },
  },
};
</script>

<style scoped>
/* Puedes agregar estilos personalizados aquí */
</style>
