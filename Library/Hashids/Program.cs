using HashidsNet;

string salt = "chanos";
string otherSalt = "chanoSS";

Hashids hashids = new(salt);
string enc = hashids.Encode(12345);
Console.WriteLine($"Encode : {enc}");
Console.WriteLine($"Decode : {string.Join(",", hashids.Decode(enc))}");

Hashids otherIds = new(otherSalt);
Console.WriteLine($"Decode : {string.Join(",", otherIds.Decode(enc))}");

int[] arr = new[] {1,2,3,4,5};
string arrEnc = hashids.Encode(arr);
Console.WriteLine($"Encode : {arrEnc}");
Console.WriteLine($"Decode : {string.Join(",", hashids.Decode(arrEnc))}");

Hashids minhashids = new(salt, 10);
Console.WriteLine($"Encode: {minhashids.Encode(1)}");