import { mount } from "@vue/test-utils";
import PriceCalculation from "@/components/priceCalculation.vue";
import { createTestingPinia } from "@pinia/testing";

describe("PriceCalculation.vue", () => {
  let wrapper;

  beforeEach(() => {
    wrapper = mount(PriceCalculation, {
      global: {
        plugins: [createTestingPinia()],
      },
    });
  });

  it("renders the form correctly", () => {
    expect(wrapper.find("form").exists()).toBe(true);
    expect(wrapper.find("#basePrice").exists()).toBe(true);
    expect(wrapper.find("#vehicleType").exists()).toBe(true);
    expect(wrapper.find('button[type="submit"]').exists()).toBe(true);
  });

  it("shows validation messages when form is submitted empty", async () => {
    await wrapper.find("form").trigger("submit.prevent");
    expect(wrapper.find(".invalid-feedback").isVisible()).toBe(true);
  });

  it("updates the basePrice data property when input changes", async () => {
    const input = wrapper.find("#basePrice");
    await input.setValue("10000");
    expect(wrapper.vm.basePrice).toBe("10000");
  });

  it("updates the vehicleType data property when select changes", async () => {
    const select = wrapper.find("#vehicleType");
    await select.setValue("car");
    expect(wrapper.vm.vehicleType).toBe("car");
  });

  it("displays the price breakdown table when price data is available", async () => {
    wrapper.vm.price = {
      basic: 1000,
      special: 500,
      association: 200,
      storage: 300,
      total: 2000,
    };
    await wrapper.vm.$nextTick();
    expect(wrapper.find("table").exists()).toBe(true);
    expect(wrapper.find("td").text()).toBe("1000");
  });
});
