<template>
  <q-page padding class="staff-master">
    <div class="q-py-lg q-gutter-sm topSec">
      <q-card class="breadcrumSection flex justify-between">
        <q-card-section class="card-header with-tools rounded">
          <q-breadcrumbs class="text-grey-9 text-h4">
            <template #separator>
              <q-icon size="1.5em" name="o_chevron_right" color="primary" />
            </template>
            <q-breadcrumbs-el label="Home" icon="o_home" clickable to="/dashboard" />
            <q-breadcrumbs-el label="Users" />
          </q-breadcrumbs>
        </q-card-section>
        <q-card-section class="card-header with-tools rounded addStaffBtn">
          <div v-if="$q.screen.gt.xs" class="flex gt-xs">
            <q-input v-model="filter" outlined class="bg-white q-mr-sm search-box" debounce="300" placeholder="Search" dense clearable>
              <template #prepend>
                <q-icon name="o_search" />
              </template>
            </q-input>
            <q-btn icon="o_add" class="q-px-lg rounded bg-pink-3" label="Add User" no-caps @click="onAdd" />
          </div>
          <q-icon v-else name="o_more_vert" size="24px">
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
                    <q-btn icon="o_add" class="q-px-lg rounded bg-pink-3" label="Add User" no-caps @click="onAdd" />
                  </q-item-section>
                </q-item>
              </q-list>
            </q-menu>
          </q-icon>
        </q-card-section>
      </q-card>
    </div>
    <q-card class="no-border">
      <q-inner-loading :showing="loader" label="Please wait..." label-class="text-teal" />
      <q-table
        v-model:pagination="pagination" :loading="loading" :rows="rows" :columns="columns" row-key="id" style="border:1px solid rgba(180, 180, 180, 0.4);" flat bordered
        no-data-label="I didn't find anything for you" :filter="filter" binary-state-sort
      >
        <template #header="props">
          <q-tr :props="props" class="bg-pink-2 text-black q-py-md" style="letter-spacing:0.6px;">
            <q-th v-for="col in props.cols" :key="col.name" :props="props">{{ col.label }}</q-th>
            <q-th auto-width class="text-center">Actions</q-th>
          </q-tr>
        </template>
        <template #body="props">
          <q-tr :props="props" :class="activeRowId == props.row.id ? 'highlight' : ''">
            <q-td style="width: 15%;">{{ props.row.username }}</q-td>
            <q-td style="width: 10%;">{{ props.row.firstName }}</q-td>
            <q-td style="width: 10%;">{{ props.row.lastName }}</q-td>
            <q-td style="width: 20%;">{{ props.row.email }}</q-td>
            <q-td style="width: 10%;">{{ props.row.phoneNumber }}</q-td>
            <q-td style="width: 10%;">{{ props.row.userRoles[0].role.name }}</q-td>
            <q-td class="text-center" style="width: 10%;">
              <q-chip v-if="props.row.active" label="Active" name="o_done" class="rounded q-px-lg" color="green-3" text-color="black" />
              <q-chip v-else name="o_clear" label="Inactive" color="grey-4" />
            </q-td>
            <q-td auto-width class="text-center actions" style="width: 15%;">
              <q-icon name="o_mail" class="cursor-pointer q-mr-sm" @click="onSendUserLoginDetails(props.row)">
                <q-tooltip>Send User Login Details</q-tooltip>
              </q-icon>
              <q-icon name="o_edit" class="cursor-pointer q-mr-sm" @click="onEdit(props.row.id)">
                <q-tooltip>Edit</q-tooltip>
              </q-icon>
              <q-icon name="o_delete_outline" class="cursor-pointer" color="negative" @click="onDelete(props.row)">
                <q-tooltip>Delete</q-tooltip>
              </q-icon>
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
import EditUser from "modules/users/components/edit_user.vue";
import usersService from "modules/users/users.service";
import { zwConfirmDelete, zwConfirm, notifySuccess } from "assets/utils";

const $q = useQuasar();
const loading = ref(false);
const loader = ref(false);
const filter = ref("");
const rows = ref([]);
const activeRowId = ref(null);
const pagination = ref({ sortBy: "createdOnUtc", descending: false, rowsPerPage: 15, page: 1 });
const columns = ref([
  { name: "username", label: "User Name", field: "username", align: "left", sortable: true },
  { name: "firstName", label: "First Name", field: "firstName", align: "left", sortable: true },
  { name: "lastName", label: "Last Name", field: "lastName", align: "left", sortable: true },
  { name: "email", label: "Email", field: "email", align: "left", sortable: true },
  { name: "phoneNumber", label: "Phone Number", field: "phoneNumber", align: "left", sortable: true },
  { name: "userRoles[0].role.name", label: "Role", field: "userRoles[0].role.name", align: "left", sortable: false },
  { name: "active", label: "Active", align: "center", field: "active", sortable: true }

]);

onMounted(() => {
  getUsers();
});

const getUsers = () => {
  loading.value = true;
  const payload = { SortBy: "createdOnUtc" };
  usersService.getUsers(payload).then((resp) => {
    rows.value = resp;
  }).finally(() => {
    loading.value = false;
  });
};

const onAdd = () => {
  $q.dialog({ component: EditUser, componentProps: {} }).onOk(() => {
    getUsers();
  }).onCancel(() => { }).onDismiss(() => { });
};

const onEdit = (id) => {
  activeRowId.value = id;
  $q.dialog({ component: EditUser, componentProps: { id } }).onOk(() => {
    getUsers();
  }).onCancel(() => { }).onDismiss(() => { activeRowId.value = null; });
};

const onDelete = (item) => {
  activeRowId.value = item.id;
  zwConfirmDelete({ data: `${item.username}, ${item.firstName}` }, () => {
    usersService.deleteUser(item.id).then(resp => {
      notifySuccess({ message: "User is deleted successfully." });
      getUsers();
    });
  }, () => {
    activeRowId.value = null;
  });
};

function onSendUserLoginDetails (item) {
  activeRowId.value = item.id;
  zwConfirm({ message: "User login details will send to " + item.email + "?" }, () => {
    loader.value = true;
    usersService.sendUserLogin(item.id).then(resp => {
      notifySuccess({ message: "Sent successfully." });
      loader.value = false;
    });
  }, () => { });
}
</script>

<style scoped>
  .staff-master{
    /* font-family: "Roboto",sans-serif; */
  }
  .staff-master .rounded{
    border-radius: 8px;
  }

  @media(max-width:768px){
    .staff-master .q-table{
      overflow-x: auto;
    }
  }
</style>
