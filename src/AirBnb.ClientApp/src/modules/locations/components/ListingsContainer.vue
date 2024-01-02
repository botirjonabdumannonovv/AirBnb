<template>

    <div class="flex flex-col items-center justify-center theme-bg-primary">

        <!-- Locations tab -->
        <listings-category-tab :listingCategories="listingCategories as ListingCategory[]"
                               :selectedCategoryId="selectedCategoryId!"
                               @onCategorySelected="onCategorySelected"/>

        <!-- Listings grid -->
        <listings-grid :selectedCategoryId="selectedCategoryId!"/>

    </div>

</template>
<script setup lang="ts">
import ListingsCategoryTab from "@/modules/locations/components/ListingsCategoryTab.vue";
import ListingsGrid from "@/modules/locations/components/ListingsGrid.vue";
import { CallbackModel } from "@/infrastructure/models/CallbackModel";
import { onBeforeMount, ref } from "vue";
import type { ListingCategory } from "@/modules/locations/models/ListingCategory";
import { AirBnbApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/AirBnbApiClient";

const airBnbApiClient = new AirBnbApiClient();

const onCategorySelectedCallback = new CallbackModel<string, void>();
const selectedCategoryId = ref<string>("");
const listingCategories = ref<Array<ListingCategory>>([]);

onBeforeMount(async () => {
    await loadListingCategories();
});

const onCategorySelected = async (categoryId: string) => {
    selectedCategoryId.value = categoryId;
    await onCategorySelectedCallback.callBack(categoryId);
}

const loadListingCategories = async () => {
    const response = await airBnbApiClient.listingCategories.getAsync()
    if (response.response) {
        listingCategories.value = response.response;
        if (response.response.length > 0) selectedCategoryId.value = response.response[0].id;
    }
};

</script>