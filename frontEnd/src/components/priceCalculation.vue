<template>
  <div class="container mt-5">
    <form @submit.prevent="submitForm" class="needs-validation" novalidate>
      <div class="form-group">
        <label for="basePrice">Vehicle Base Price</label>
        <input type="text" class="form-control" id="basePrice" v-model="basePrice" required />
        <div class="invalid-feedback">Please enter the base price.</div>
      </div>
      <div class="form-group">
        <label for="vehicleType">Vehicle Type</label>
        <select class="form-control" id="vehicleType" v-model="vehicleType" required>
          <option v-for="option in options" :key="option.value" :value="option.value">
            {{ option.text }}
          </option>
        </select>
        <div class="invalid-feedback">Please select a vehicle type.</div>
      </div>
      <br />
      <button type="submit" class="btn btn-primary btn-block">Submit</button>
    </form>
    <br />
    <div v-if="price">
      <div class="card">
        <div class="card-header bg-primary text-white">Price Breakdown</div>
        <div class="card-body">
          <table class="table table-bordered">
            <thead class="thead-dark">
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
                <td>{{ price.basic }}</td>
                <td>{{ price.special }}</td>
                <td>{{ price.association }}</td>
                <td>{{ price.storage }}</td>
                <td>{{ price.total }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { usePriceStore } from "../stores/priceStore";

export default defineComponent({
  name: "PriceCalculation",
  setup() {
    const { basePrice, vehicleType, options, price, submitForm } = usePriceStore();

    return {
      basePrice,
      vehicleType,
      options,
      price,
      submitForm,
    };
  },
});
</script>

<style scoped>
/* Add custom styles here */
.container {
  max-width: 600px;
}

.table {
  margin-top: 20px;
}

.invalid-feedback {
  display: none;
}

input:invalid + .invalid-feedback,
select:invalid + .invalid-feedback {
  display: block;
}

.card {
  margin-top: 20px;
}

.card-header {
  font-size: 1.25rem;
}

.btn-block {
  width: 100%;
}
</style>
