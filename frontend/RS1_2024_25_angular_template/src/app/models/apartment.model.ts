export interface Image {
  imageID: number;
  imagePath: string;
}

export interface ApartmentImage {
  apartmentImageID: number;
  apartmentId: number;
  imageID: number;
  image: Image;
}

export interface City {
  id: number;
  name: string;
  countryId: number;
  country: Country;
}

export interface Country {
  id: number;
  name: string;
}

export interface Reservation {
  reservationId: number;
  accountId: number;
  account: Account;
}

export interface Apartment {
  apartmentId: number;
  name: string;
  description: string;
  adress: string;
  pricePerNight: number;
  cityName: string;
  countryName: string;
  amenities: string[];
  toiletries: string[];
  rules: string[];
  imagePaths: string[];
  apartmentImages?: ApartmentImage[];
}

export interface Account {
  accountId: number;
  username: string;
  email: string;
}

export interface ApartmentRule {
  ruleId: number;
  ruleName: string;
}

export interface ApartmentAmenity {
  amenityId: number;
  amenityName: string;
}

export interface ApartmentToiletry {
  toiletryId: number;
  toiletryName: string;
}
