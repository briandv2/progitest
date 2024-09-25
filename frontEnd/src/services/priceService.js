// services/priceService.js
import axios from "axios";

const API_URL = "https://localhost:7134/api/CalculatePrice";

export const calculatePrice = async (basePrice, vehicleType) => {
  try {
    const response = await axios.post(API_URL, {
      price: basePrice,
      vehicleType: vehicleType,
    });
    return response.data;
  } catch (error) {
    console.error("Error al enviar el formulario:", error);
    throw error;
  }
};
