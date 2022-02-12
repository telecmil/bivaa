<template>
  <v-data-table :headers="headers"
                :items="devices"
                sort-by="device_name"
                class="elevation-1">
    <template v-slot:top>
      <v-toolbar flat>
        <v-toolbar-title>Examination Devices</v-toolbar-title>
        <v-divider class="mx-4"
                   inset
                   vertical></v-divider>
        <v-spacer></v-spacer>
        <v-dialog v-model="dialog"
                  max-width="500px">
          <template v-slot:activator="{ on, attrs }">
            <v-btn color="primary"
                   dark
                   class="mb-2"
                   v-bind="attrs"
                   v-on="on">
              New Device
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="text-h5">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12"
                         sm="6"
                         md="4">
                    <v-text-field v-model="editedItem.device_name"
                                  label="Device name"></v-text-field>
                  </v-col>
                  <v-col cols="12"
                         sm="6"
                         md="4">
                    <v-text-field v-model="editedItem.last_inspection"
                                  label="Last Inspection"></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1"
                     text
                     @click="close">
                Cancel
              </v-btn>
              <v-btn color="blue darken-1"
                     text
                     @click="save">
                Save
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="text-h5">Are you sure you want to delete this device?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:item.actions="{ item }">
      <v-icon small
              class="mr-2"
              @click="editItem(item)">
        mdi-pencil
      </v-icon>
      <v-icon small
              @click="deleteItem(item)">
        mdi-delete
      </v-icon>
    </template>
  </v-data-table>
</template>

<script>
  export default {
    data: () => ({
      dialog: false,
      dialogDelete: false,
      headers: [
        {
          text: 'Device name',
          align: 'start',
          sortable: true,
          value: 'device_name',
        },
        { text: 'Last inspection', value: 'last_inspection' },
        { text: 'Actions', value: 'actions', sortable: false },
      ],
      devices: [],
      editedIndex: -1,
      editedItem: {
        device_name: '',
        last_inspection: '',
      },
      defaultItem: {
        device_name: '',
        last_inspection: '',
      },
    }),

    computed: {
      formTitle() {
        return this.editedIndex === -1 ? 'New Device' : 'Edit Device'
      },
    },
    async mounted() {
      const res = await this.$axios.get('/device/GetDevices');
      console.log(res.data);
      this.devices = res.data;
      //this.devices = await fetch('http://localhost:63874/api/device/GetDevices').then((res) => res.json())
    },


    watch: {
      dialog(val) {
        val || this.close()
      },
      dialogDelete(val) {
        val || this.closeDelete()
      },
    },



    methods: {

      editItem(item) {
        this.editedIndex = this.devices.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialog = true
      },

      deleteItem(item) {
        this.editedIndex = this.devices.indexOf(item)
        this.editedItem = Object.assign({}, item)
        this.dialogDelete = true
      },

      deleteItemConfirm() {
        this.devices.splice(this.editedIndex, 1)
        this.closeDelete()
      },

      close() {
        this.dialog = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      closeDelete() {
        this.dialogDelete = false
        this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
        })
      },

      save() {
        if (this.editedIndex > -1) {
          Object.assign(this.devices[this.editedIndex], this.editedItem)
        } else {
          
          const res = this.$axios.post('/device/PostDevice', this.editedItem)
          console.log(res.data);
          this.devices.push(res.data)
        }
        this.close()
      },
    },
  }
</script>



<!-- <script>
export default {
    data() {
      return {
        devices: []
      }
    },
    computed: {
      headers() {
        return [
          {
            text: 'ID',
            align: 'start',
            sortable: true,
            value: 'device_ID'
          },
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'device_name'
          },
          {
            text: 'Last inspection',
            align: 'start',
            sortable: true,
            value: 'last_inspection'
          }          
        ]
      }

    },
    async mounted() {
      const res = await this.$axios.get('/device/GetDevices');
      console.log(res.data);
      this.devices = res.data;
      //this.devices = await fetch('http://localhost:63874/api/device/GetDevices').then((res) => res.json())
    }
    }
</script> -->
