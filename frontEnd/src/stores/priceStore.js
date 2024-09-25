// stores/priceStore.js
import { ref } from "vue";
import { calculatePrice } from "../services/priceService";

export const usePriceStore = () => {
  const basePrice = ref("");
  const vehicleType = ref("");
  const options = ref([
    { value: 1, text: "common" },
    { value: 2, text: "Luxury" },
  ]);
  const price = ref(null);

  const submitForm = async () => {
    try {
      price.value = await calculatePrice(basePrice.value, vehicleType.value);
    } catch (error) {
      console.error("Error al enviar el formulario:", error);
    }
  };

  return {
    basePrice,
    vehicleType,
    options,
    price,
    submitForm,
  };
};
