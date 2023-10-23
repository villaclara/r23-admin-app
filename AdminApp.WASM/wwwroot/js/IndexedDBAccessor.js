export function initialize() {
    let indexedDBConnection = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
    indexedDBConnection.onupgradeneeded = function () {
        let db = indexedDBConnection.result;
            db.createObjectStore("candles", { keyPath: "id" });      
            db.createObjectStore("orders", { keyPath: "id" });
    }
}

export function set(collectionName, value) {
    let indexedDBConnection = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);

    indexedDBConnection.onsuccess = function () {
        let transaction = indexedDBConnection.result.transaction(collectionName, "readwrite");
        let collection = transaction.objectStore(collectionName)
        collection.put(value);
    }
}


export async function get(collectionName, id) {
    let request = new Promise((resolve) => {
        let indexedDBConnection = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);
        indexedDBConnection.onsuccess = function () {
            let transaction = indexedDBConnection.result.transaction(collectionName, "readonly");
            let collection = transaction.objectStore(collectionName);
            let result = collection.get(id);

            result.onsuccess = function (e) {
                resolve(result.result);
            }
        }
    });

    let result = await request;

    return result;
}


export async function getAll(collectionName) {
    let request = new Promise((resolve) => {
        let indexedDBConnection = indexedDB.open(DATABASE_NAME, CURRENT_VERSION);

        indexedDBConnection.onsuccess = function () {
            let transaction = indexedDBConnection.result.transaction(collectionName, "readonly");
            let collection = transaction.objectStore(collectionName);

            let result = collection.getAll();

            result.onsuccess = function (e) {
                resolve(result.result);
            }
        }

    });

    let result = await request;
    return result;
}

let CURRENT_VERSION = 1;
let DATABASE_NAME = "indexed-db-1";