import { Coordinates } from "@/common/models/request/Location";
import type { Region } from "@/common/models/request/Region";

export class UserInfo {

    public coordinates!: Coordinates;

    public region!: Region;
}