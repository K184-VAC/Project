<script setup lang="ts">
    interface Team {
        id: number;
        name: string;
        DAE: DatesAndEvents[];
    }

    interface DatesAndEvents {
        dates: string;
        events: string;
    }

    var teamList: Team[] = [
        {
            id: 0,
            name: '',
            DAE: [
                {
                    dates: '',
                    events: ''
                }
            ]
        }
    ]
    // just for example
    for (let i = 0; i < 4; i++) {
        if (i == 0) {
            teamList[i].id = i + 1;
            teamList[i].name = 'Komanda ' + (i + 1);
            teamList[i].DAE = [
                {
                    dates: '2022-03-21',
                    events: 'Planning'
                },
                {
                    dates: '2022-03-23',
                    events: 'Standup'
                },
                {
                    dates: '2022-03-25',
                    events: 'Retro'
                }];
        }
        else {
            const team: Team = {
                id: i + 1,
                name: 'Komanda ' + (i + 1),
                DAE: [
                    {
                        dates: '2022-03-21',
                        events: 'Planning'
                    },
                    {
                        dates: '2022-03-23',
                        events: 'Standup'
                    },
                    {
                        dates: '2022-03-25',
                        events: 'Retro'
                    }
                ]
            };
            teamList.push(team);
        }
    }

</script>
<template>
    <div class="mt-4 mb-4 ms-4">
        <router-link to="/teams/add" class="ml-3 btn btn-primary" tag="button">Sukurti komandą</router-link>
    </div>
    <div class="row">
        <div class="col-2 mt-4 mb-4 ms-4">
            <div class="list-group" id="list-tab" role="tablist">
                <a v-for="team in teamList" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center" data-bs-toggle="list" v-bind:href="'#list-team' + team.id" role="tab">{{team.name}}
                    <span class="badge bg-warning rounded-pill">{{team.DAE.length}}</span>
                </a>
            </div>
        </div>
        <div class="col-8 mt-4 mb-4 ms-4">
            <div class="tab-content" id="nav-tabContent">
                <div v-for="team in teamList" class="tab-pane fade" :id="'list-team' + team.id" role="tabpanel">
                    <div>
                        <router-link to="/teams/edit" class="ml-3 btn btn-warning" tag="button">Redaguoti</router-link>
                    </div>
                    <div class="pe-1">
                        <table class="table table-striped table-hover">
                            <thead class="table-light">
                                <tr>
                                    <th style="width: 16%">Data</th>
                                    <th style="width: 30%">Įvykis</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="dae in team.DAE">
                                    <td>{{dae.dates}}</td>
                                    <td>{{dae.events}}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>
