import { ListingsCategoryEndpointClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/ListingsCategoryEndpointClient";
import ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";
import { ListingsEndpointClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/ListingsEndpointClient";

export class AirBnbApiClient {
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7172";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl,
            withCredentials: true
        });

        this.listingCategories = new ListingsCategoryEndpointClient(this.client);
        this.listings = new ListingsEndpointClient(this.client);
    }

    public listingCategories: ListingsCategoryEndpointClient;

    public listings: ListingsEndpointClient;
}