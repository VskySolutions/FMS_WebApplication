<template>
  <q-page padding class="Roles-master">
  <div class="q-py-lg q-gutter-sm">
    <q-card class="breadcrumSection flex justify-between">
      <q-card-section class="card-header with-tools rounded">
        <q-breadcrumbs class="text-grey-9 text-h4">
          <template v-slot:separator>
            <q-icon size="1.5em" name="o_chevron_right" color="primary" />
          </template>
          <q-breadcrumbs-el label="Home" icon="o_home" clickable to="/dashboard" />
          <q-breadcrumbs-el label="Roles" />
        </q-breadcrumbs>
      </q-card-section>
      <q-card-section class="card-header with-tools rounded actions" v-if="$q.screen.gt.xs">
        <div class="flex">
          <q-input v-model="filter" outlined class="bg-white q-mr-sm search-box" debounce="300" placeholder="Search" dense clearable>
            <template #prepend>
              <q-icon name="o_search" />
            </template>
          </q-input>
          <q-btn v-if="hasManagePermission === true" color="primary" icon="o_add" class="rounded-corners bg-pink-3 text-black" label="Add Role" no-caps @click="onAdd" />
        </div>
      </q-card-section>
      <q-card-section v-else>
        <q-icon name="o_more_vert" size="24px">
          <q-menu class="">
            <q-list dense style="min-width: 100px" class="q-gutter-y-sm q-my-md">
              <q-item>
                <q-item-section>
                  <q-input v-model="filter" outlined class="bg-white q-mr-sm search-box" debounce="300" placeholder="Search" dense clearable>
                    <template #prepend>
                      <q-icon name="o_search" />
                    </template>
                  </q-input>
                </q-item-section>
              </q-item>
              <q-item v-close-popup>
                <q-item-section>
                  <q-btn v-if="hasManagePermission === true" color="primary" icon="o_add" class="rounded-corners bg-pink-3 text-black" label="Add Role" no-caps @click="onAdd" />
                </q-item-section>
              </q-item>
            </q-list>
          </q-menu>
        </q-icon>
      </q-card-section>
    </q-card>
  </div>
    <q-card class="no-border">
      <!-- <q-card-section class="card-header with-tools bg-pink-1 rounded q-mb-lg">
        <h1 class="text-pink-4 text-bolder" style="letter-spacing:1px">Roles</h1>
        <div class="flex">
          <q-input v-model="filter" outlined class="bg-white q-mr-sm search-box" debounce="300" placeholder="Search" dense clearable>
            <template #prepend>
              <q-icon name="o_search" />
            </template>
          </q-input>
        </div>
      </q-card-section> -->
      <!-- <q-separator /> -->
      <q-table
        v-model:pagination="pagination" :loading="loading" :rows="rows" :columns="columns" row-key="id" style="border:1px solid rgba(180, 180, 180, 0.4);max-width:100%" flat bordered
        no-data-label="I didn't find anything for you" :filter="filter" binary-state-sort
      >
        <template #header="props">
          <q-tr :props="props" class="bg-pink-2 text-black q-py-md" style="letter-spacing:0.6px;">
            <q-th v-for="col in props.cols" :key="col.name" :props="props">{{ col.label }}</q-th>
            <q-th v-if="hasManagePermission === true" class="text-center">Actions</q-th>
          </q-tr>
        </template>
        <template #body="props">
          <q-tr :props="props" :class="activeRowId == props.row.id ? 'highlight' : ''">
            <q-td>{{ props.row.name }}</q-td>
            <q-td v-if="hasManagePermission === true" class="text-center actions">
              <q-icon name="o_manage_accounts" class="cursor-pointer q-mr-sm" @click="$router.push('/roles/'+props.row.id+'/permissions')">
                <q-tooltip>Manage Permissions</q-tooltip>
              </q-icon>
              <span v-if="hasManagePermission === true">
                <q-icon v-if="props.row.name === 'Administrator' || props.row.name === 'SystemUser'" name="o_edit" class="q-mr-sm" style="opacity: 0.5;">
                  <q-tooltip>You cannot edit this role</q-tooltip>
                </q-icon>
                <q-icon v-if="props.row.name !== 'Administrator' && props.row.name !== 'SystemUser'" name="o_edit" class="cursor-pointer q-mr-sm" @click="onEdit(props.row.id)">
                  <q-tooltip>Edit</q-tooltip>
                </q-icon>
              </span>
              <!-- <q-icon name="o_delete_outline" class="cursor-pointer" color="negative" @click="onDelete(props.row)">
                <q-tooltip>Delete</q-tooltip>
              </q-icon> -->
            </q-td>
          </q-tr>
        </template>
      </q-table>
    </q-card>
  </q-page>
</template>
<script setup>
import { ref, onMounted } from "vue";
import { useQuasar } from "quasar";
import EditRole from "modules/roles/components/edit_role.vue";
import roleService from "modules/roles/role.service";
// import moduleService from "modules/module/module.service";

const hasManagePermission = ref(false);
const $q = useQuasar();
const loading = ref(false);
const rows = ref([]);
const filter = ref("");
const activeRowId = ref(null);
const pagination = ref({ sortBy: "name", descending: false, rowsPerPage: 15, page: 1 });
const columns = ref([
  { name: "name", label: "Role Name", field: "name", align: "left", sortable: true }
]);

onMounted(() => {
  getRoles();
  // getMenuManagePermission();
});

const getRoles = () => {
  loading.value = true;
  roleService.getRoles().then((resp) => {
    rows.value = resp.data;
    console.log(rows.value);
  }).finally(() => {
    loading.value = false;
  });
};

// const getMenuManagePermission = () => {
//   moduleService.getMenuManagePermission("M-roles").then((resp) => {
//     if (resp.isManage === true) {
//       hasManagePermission.value = true;
//     }
//   }).finally(() => {
//   });
// };

const onAdd = () => {
  $q.dialog({
    component: EditRole,
    componentProps: {}
  }).onOk(() => {
    getRoles();
  }).onCancel(() => {
  }).onDismiss(() => {
  });
};

const onEdit = (id) => {
  activeRowId.value = id;
  $q.dialog({
    component: EditRole,
    componentProps: { id }
  }).onOk(() => {
    getRoles();
  }).onCancel(() => {
  }).onDismiss(() => {
    activeRowId.value = null;
  });
};

</script>
<style scoped>
</style>
